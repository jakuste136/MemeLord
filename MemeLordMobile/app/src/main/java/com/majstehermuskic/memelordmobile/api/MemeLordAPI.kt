package com.majstehermuskic.memelordmobile.api

import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Query

// TODO: Przemyśleć
interface MemeLordAPI {
    @GET("post/get-posts")
    fun getPosts(@Query("lastid") lastid: Int,
                 @Query("count") count: Int): Call<GetPostsResponse>
}