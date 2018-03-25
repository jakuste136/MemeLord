package com.majstehermuskic.memelordmobile.api

import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Query

interface MemeLordAPI {
    @GET("post/getPosts")
    fun getPosts(@Query("lastid") lastid: Int,
                 @Query("count") count: Int): Call<MemePostsResponse>
}