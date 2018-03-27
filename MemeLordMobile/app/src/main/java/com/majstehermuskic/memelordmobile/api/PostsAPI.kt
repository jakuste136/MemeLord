package com.majstehermuskic.memelordmobile.api

import retrofit2.Call

/**
 * Created by Bartosz on 2018-03-22.
 */
interface PostsAPI {
    fun getPosts(lastid: Int, count: Int): Call<GetPostsResponse>
}