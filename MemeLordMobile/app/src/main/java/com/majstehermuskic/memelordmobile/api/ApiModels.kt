package com.majstehermuskic.memelordmobile.api

class MemePostsResponse(
        val postsList: List<MemePostResponse>,
        val lastId: Int
)

class MemePostResponse(
        val title: String,
        val image: String
)