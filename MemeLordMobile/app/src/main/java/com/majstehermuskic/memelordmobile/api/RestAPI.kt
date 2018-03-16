package com.majstehermuskic.memelordmobile.api

import retrofit2.Call
import retrofit2.Retrofit
import retrofit2.converter.moshi.MoshiConverterFactory

// TODO: Zmienić z reddit api na nasze api
class RestAPI {

    private lateinit var redditApi: RedditApi

    init {
        val retrofit = Retrofit.Builder()
                .baseUrl("https://www.reddit.com")
                .addConverterFactory(MoshiConverterFactory.create())
                .build()

        redditApi = retrofit.create(RedditApi::class.java)
    }

    fun getNews(after: String, limit: String): Call<RedditNewsResponse> {
        return redditApi.getTop(after, limit)
    }
}