package com.majstehermuskic.memelordmobile.api

import okhttp3.MultipartBody
import okhttp3.RequestBody
import okhttp3.ResponseBody
import retrofit2.Call

interface AddPostAPI {
    fun addPost(image: MultipartBody.Part, title: RequestBody): Call<ResponseBody>
}