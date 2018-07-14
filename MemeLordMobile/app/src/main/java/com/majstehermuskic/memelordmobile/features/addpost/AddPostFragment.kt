package com.majstehermuskic.memelordmobile.features.addpost

import android.app.Activity
import android.os.Bundle
import android.support.design.widget.Snackbar
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import com.majstehermuskic.memelordmobile.MemeLordApp
import com.majstehermuskic.memelordmobile.R
import com.majstehermuskic.memelordmobile.api.AddPostAPI
import com.majstehermuskic.memelordmobile.api.AddPostResponse
import com.majstehermuskic.memelordmobile.commons.RxBaseFragment
import com.majstehermuskic.memelordmobile.commons.extensions.inflate
import kotlinx.android.synthetic.main.fragment_add_post.*
import kotlinx.android.synthetic.main.fragment_login.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import javax.inject.Inject
import android.provider.MediaStore
import android.content.Intent
import android.graphics.Bitmap
import android.graphics.BitmapFactory
import android.net.Uri
import android.os.Environment
import android.support.v4.content.FileProvider
import okhttp3.MediaType
import java.io.File
import okhttp3.RequestBody
import okhttp3.MultipartBody
import okhttp3.ResponseBody
import id.zelory.compressor.Compressor


class AddPostFragment : RxBaseFragment() {

    @Inject
    lateinit var api: AddPostAPI

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        MemeLordApp.addPostComponent.inject(this)
    }

    override fun onCreateView(inflater: LayoutInflater?, container: ViewGroup?,
                              savedInstanceState: Bundle?): View? {
        return container?.inflate(R.layout.fragment_add_post)
    }

    override fun onActivityCreated(savedInstanceState: Bundle?) {
        super.onActivityCreated(savedInstanceState)

        buttonAddImage.setOnClickListener {
            dispatchTakePictureIntent()
        }

        buttonSendPost.setOnClickListener {
            sendPost()
        }
    }

    private var imageUri: Uri? = null
    var image: File? = null

    private fun dispatchTakePictureIntent() {
        val takePictureIntent = Intent(MediaStore.ACTION_IMAGE_CAPTURE)

        val storageDir = context.getExternalFilesDir(Environment.DIRECTORY_PICTURES)
        image = File.createTempFile(
                "photoxd", /* prefix */
                ".jpg", /* suffix */
                storageDir      /* directory */
        )

        imageUri = FileProvider.getUriForFile(context,
                "com.majstehermuskic.memelordmobile.provider",
                image)


        takePictureIntent.putExtra(MediaStore.EXTRA_OUTPUT, imageUri)
        if (takePictureIntent.resolveActivity(context.packageManager) != null) {
            startActivityForResult(takePictureIntent, 1)
        }
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {
        super.onActivityResult(requestCode, resultCode, data)
        if (requestCode == 1 && resultCode == Activity.RESULT_OK) {
            imageView.setImageBitmap(BitmapFactory.decodeFile(image?.absolutePath))
        }
    }

    private fun sendPost() {

        if(image != null && !editTitle.text.toString().isNullOrEmpty()) {

            val config = BitmapFactory.Options()
            config.inJustDecodeBounds = true
            BitmapFactory.decodeFile(image!!.absolutePath, config)

            image = Compressor(context)
                    .setMaxWidth(1000)
                    .setMaxHeight(config.outHeight / config.outWidth * 1000)
                    .setQuality(75)
                    .setCompressFormat(Bitmap.CompressFormat.JPEG)
                    .compressToFile(image)

            val requestFile = RequestBody.create(
                    MediaType.parse(context.contentResolver.getType(imageUri)),
                    image
            )

            val body = MultipartBody.Part.createFormData("image", image!!.name, requestFile)

            val descriptionString = editTitle.text.toString()
            val title = RequestBody.create(okhttp3.MultipartBody.FORM, descriptionString)

            val callResponse = api.addPost(body, title)
            callResponse.enqueue(object : Callback<ResponseBody> {
                override fun onResponse(call: Call<ResponseBody>?, response: Response<ResponseBody>?) {
                    Snackbar.make(buttonSendPost, "Uploaded meme successfully", Snackbar.LENGTH_LONG).show()
                    activity.onBackPressed()
                }

                override fun onFailure(call: Call<ResponseBody>?, t: Throwable?) {
                    Snackbar.make(buttonSendPost, t?.message ?: "", Snackbar.LENGTH_LONG).show()
                }
            })
        }
        else{
            Snackbar.make(buttonSendPost, "No title or image.", Snackbar.LENGTH_LONG).show()
        }
    }

}// Required empty public constructor