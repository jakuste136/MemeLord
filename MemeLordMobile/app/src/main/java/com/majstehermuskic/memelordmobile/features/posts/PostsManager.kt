package com.majstehermuskic.memelordmobile.features.posts

import com.majstehermuskic.memelordmobile.api.RestAPI
import com.majstehermuskic.memelordmobile.commons.MemePostItem
import com.majstehermuskic.memelordmobile.commons.MemePosts
import io.reactivex.Observable

class PostsManager(private val api: RestAPI = RestAPI()) {

    fun getPosts(last: Int = 0, count: Int = 10): Observable<MemePosts> {
        return Observable.create {
            subscriber ->
            val callResponse = api.getPosts(last, count)
            val response = callResponse.execute()

            if(response.isSuccessful) {
                val postsResponse = response.body()
                val posts = postsResponse!!.postsList.map {
                    MemePostItem(it.title, it.image)
                }
                val memePosts = MemePosts(
                        postsResponse.lastId,
                        posts
                )
                subscriber.onNext(memePosts)
                subscriber.onComplete()
            } else {
                subscriber.onError(Throwable(response.message()))
            }
        }
    }

}