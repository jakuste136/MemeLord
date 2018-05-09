package com.majstehermuskic.memelordmobile.api

import okhttp3.MultipartBody
import okhttp3.RequestBody
import retrofit2.Call
import javax.inject.Inject

class AddPostRestAPI @Inject constructor(private val memeLordApi:MemeLordAPI): AddPostAPI {
    override fun addPost(image: MultipartBody.Part, title: RequestBody): Call<AddPostResponse> {
        return memeLordApi.addPost(image, title)
    }
}