package com.majstehermuskic.memelordmobile.api

import android.text.SpannableStringBuilder

class GetPostsResponse(
        val postsList: List<PostDto>,
        val lastId: Int
)

class PostDto(
        val title: String,
        val image: String
)

class LoginResponse(
        val accessToken: String,
        val tokenType: String,
        val expiresIn: Int,
        val role: String
)