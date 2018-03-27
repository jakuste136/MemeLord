package com.majstehermuskic.memelordmobile.features.posts

import com.majstehermuskic.memelordmobile.api.PostsAPI
import com.majstehermuskic.memelordmobile.api.PostsRestAPI
import com.majstehermuskic.memelordmobile.commons.MemePostItem
import com.majstehermuskic.memelordmobile.commons.MemePosts
import io.reactivex.Observable
import javax.inject.Inject
import javax.inject.Singleton

@Singleton
class PostsManager @Inject constructor(private val api: PostsAPI) {

    fun getPosts(last: Int, count: Int = 10): Observable<MemePosts> {
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