package com.majstehermuskic.memelordmobile.api

import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Query

// TODO: Usunąć interfejs i stworzyć odpowiedni dla naszego api
interface RedditApi {
    @GET("/top.json")
    fun getTop(@Query("after") after: String,
               @Query("limit") limit: String): Call<RedditNewsResponse>
}