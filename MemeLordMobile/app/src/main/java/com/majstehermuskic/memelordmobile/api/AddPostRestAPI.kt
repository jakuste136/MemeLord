package com.majstehermuskic.memelordmobile.api

import okhttp3.MultipartBody
import okhttp3.RequestBody
import okhttp3.ResponseBody
import retrofit2.Call
import javax.inject.Inject

class AddPostRestAPI @Inject constructor(private val memeLordApi:MemeLordAPI): AddPostAPI {
    override fun addPost(image: MultipartBody.Part, title: RequestBody): Call<ResponseBody> {
        return memeLordApi.addPost(image, title)
    }
}