package com.majstehermuskic.memelordmobile.commons

import com.majstehermuskic.memelordmobile.commons.adapter.AdapterConstants
import com.majstehermuskic.memelordmobile.commons.adapter.ViewType


data class MemePosts(
        val lastId: Int,
        val posts: List<MemePostItem>
)

data class MemePostItem(
        val title: String,
        val image: String
) : ViewType{
    override fun getViewType() = AdapterConstants.POSTS
}
