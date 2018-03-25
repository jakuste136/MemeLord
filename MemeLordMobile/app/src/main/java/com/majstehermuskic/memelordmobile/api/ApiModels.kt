package com.majstehermuskic.memelordmobile.api

class GetPostsResponse(
        val postsList: List<PostDto>,
        val lastId: Int
)

class PostDto(
        val title: String,
        val image: String
)