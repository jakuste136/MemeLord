package com.majstehermuskic.memelordmobile.api

import retrofit2.Call
import retrofit2.Retrofit
import retrofit2.converter.moshi.MoshiConverterFactory

class RestAPI {

    private lateinit var memeLordApi: MemeLordAPI

    init {
        val retrofit = Retrofit.Builder()
                .baseUrl("http://192.168.0.108:3000/api/")
                .addConverterFactory(MoshiConverterFactory.create())
                .build()

        memeLordApi = retrofit.create(MemeLordAPI::class.java)
    }

    fun getPosts(last: Int, count: Int): Call<MemePostsResponse> {
        return memeLordApi.getPosts(last, count)
    }
}