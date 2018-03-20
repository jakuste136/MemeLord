package com.majstehermuskic.memelordmobile.features.posts

import com.majstehermuskic.memelordmobile.api.RestAPI
import com.majstehermuskic.memelordmobile.commons.MemePostItem
import io.reactivex.Observable

class PostsManager(private val api: RestAPI = RestAPI()) {

    fun getPosts(last: Int = 0, count: Int = 10): Observable<List<MemePostItem>> {
        return Observable.create {
            subscriber ->
            val callResponse = api.getPosts(last, count)
            val response = callResponse.execute()

            if(response.isSuccessful) {
                val posts = response.body()!!.posts.map {
                    MemePostItem(it.title, it.image)
                }
                subscriber.onNext(posts)
                subscriber.onComplete()
            } else {
                subscriber.onError(Throwable(response.message()))
            }
        }
    }

}