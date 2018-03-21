package com.majstehermuskic.memelordmobile.api

class MemePostsResponse(
        val posts: List<MemePostResponse>,
        val last: Int
)

class MemePostResponse(
        val title: String,
        val image: String
)