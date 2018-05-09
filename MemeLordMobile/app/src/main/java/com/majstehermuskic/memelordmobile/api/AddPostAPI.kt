package com.majstehermuskic.memelordmobile.api

import okhttp3.MultipartBody
import okhttp3.RequestBody
import retrofit2.Call

interface AddPostAPI {
    fun addPost(image: MultipartBody.Part, title: RequestBody): Call<AddPostResponse>
}