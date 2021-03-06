package com.majstehermuskic.memelordmobile.api

import retrofit2.Call
import javax.inject.Inject

class PostsRestAPI @Inject constructor(private val memeLordApi: MemeLordAPI): PostsAPI {

    override fun getPosts(lastid: Int, count: Int): Call<GetPostsResponse> {
        return memeLordApi.getPosts(lastid, count)
    }
}