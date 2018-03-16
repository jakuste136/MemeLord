package com.majstehermuskic.memelordmobile.features.posts

import com.majstehermuskic.memelordmobile.api.RestAPI
import com.majstehermuskic.memelordmobile.commons.MemePostItem
import io.reactivex.Observable

class PostsManager(private val api: RestAPI = RestAPI()) {

    fun getPosts(limit: String = "10"): Observable<List<MemePostItem>> {
        return Observable.create {
            subscriber ->
            val callResponse = api.getNews("", limit)
            val response = callResponse.execute()

            if(response.isSuccessful) {
                val posts = response.body()!!.data.children.map {
                    val item = it.data
                    MemePostItem(item.title, item.thumbnail)
                }
                subscriber.onNext(posts)
                subscriber.onComplete()
            } else {
                subscriber.onError(Throwable(response.message()))
            }


//            val posts = mutableListOf<MemePostItem>()
//            for (i in 1..10) {
//                posts.add(MemePostItem(
//                        "Title $i",
//                        "https://picsum.photos/200/200?image=$i"
//                ))
//            }
//            subscriber.onNext(posts)
        }
    }

}