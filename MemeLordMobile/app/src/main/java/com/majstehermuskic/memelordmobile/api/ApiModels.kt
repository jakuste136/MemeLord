package com.majstehermuskic.memelordmobile.api

class GetPostsResponse(
        val postsList: List<PostDto>,
        val lastId: Int
)

class PostDto(
        val title: String,
        val image: String
)

class LoginResponse(
        val access_token: String
)

class AddPostResponse