package com.majstehermuskic.memelordmobile.api

import retrofit2.Call
import retrofit2.http.*

// TODO: Przemyśleć
interface MemeLordAPI {
    @GET("api/post")
    fun getPosts(@Query("lastid") lastid: Int,
                 @Query("count") count: Int): Call<GetPostsResponse>

    @FormUrlEncoded
    @Headers("content-type: application/x-www-form-urlencoded")
    @POST("token")
    fun login(@Field("username") username: String,
              @Field("password") password: String,
              @Field("grant_type") grantType: String = "password"): Call<LoginResponse>
}