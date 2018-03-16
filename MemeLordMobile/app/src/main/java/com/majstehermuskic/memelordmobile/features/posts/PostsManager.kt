package com.majstehermuskic.memelordmobile.features.posts

import com.majstehermuskic.memelordmobile.commons.MemePostItem
import io.reactivex.Observable

/**
 * Created by Bartosz on 2018-03-16.
 */
class PostsManager {

    fun getPosts(): Observable<List<MemePostItem>> {
        return Observable.create { subscriber ->

            val posts = mutableListOf<MemePostItem>()
            for (i in 1..10) {
                posts.add(MemePostItem(
                        "Title $i",
                        "https://picsum.photos/200/200?image=$i"
                ))
            }
            subscriber.onNext(posts)
        }
    }

}