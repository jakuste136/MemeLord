package com.majstehermuskic.memelordmobile.features.addpost

import android.os.Bundle
import android.support.design.widget.Snackbar
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import com.majstehermuskic.memelordmobile.MemeLordApp
import com.majstehermuskic.memelordmobile.R
import com.majstehermuskic.memelordmobile.api.AddPostAPI
import com.majstehermuskic.memelordmobile.api.AddPostResponse
import com.majstehermuskic.memelordmobile.api.LoginResponse
import com.majstehermuskic.memelordmobile.commons.RxBaseFragment
import com.majstehermuskic.memelordmobile.commons.extensions.inflate
import com.majstehermuskic.memelordmobile.features.authorization.AuthorizationInterceptor
import kotlinx.android.synthetic.main.fragment_add_post.*
import kotlinx.android.synthetic.main.fragment_login.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import javax.inject.Inject

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

        }

        buttonSendPost.setOnClickListener{
            //sendPost()
        }
    }

    private fun sendPost() {

//        val callResponse = api.addPost()
//        callResponse.enqueue(object: Callback<AddPostResponse> {
//            override fun onResponse(call: Call<AddPostResponse>?, response: Response<AddPostResponse>?) {
//
//            }
//
//            override fun onFailure(call: Call<AddPostResponse>?, t: Throwable?) {
//                Snackbar.make(buttonLogin, t?.message ?: "", Snackbar.LENGTH_LONG).show()
//            }
//        }
//        )
    }

}// Required empty public constructor