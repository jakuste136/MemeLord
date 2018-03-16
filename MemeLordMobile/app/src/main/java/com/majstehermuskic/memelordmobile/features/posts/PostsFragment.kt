package com.majstehermuskic.memelordmobile.features.posts


import android.os.Bundle
import android.support.design.widget.Snackbar
import android.support.v4.app.Fragment
import android.support.v7.widget.LinearLayoutManager
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import com.majstehermuskic.memelordmobile.R
import com.majstehermuskic.memelordmobile.commons.MemePostItem
import com.majstehermuskic.memelordmobile.commons.RxBaseFragment
import com.majstehermuskic.memelordmobile.commons.extensions.inflate
import com.majstehermuskic.memelordmobile.features.posts.adapter.PostsAdapter
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.schedulers.Schedulers
import kotlinx.android.synthetic.main.fragment_posts.*


/**
 * A simple [Fragment] subclass.
 */
class PostsFragment : RxBaseFragment() {

    private val postsManager by lazy { PostsManager() }

    override fun onCreateView(inflater: LayoutInflater?, container: ViewGroup?,
                              savedInstanceState: Bundle?): View? {
        return container?.inflate(R.layout.fragment_posts)
    }

    override fun onActivityCreated(savedInstanceState: Bundle?) {
        super.onActivityCreated(savedInstanceState)

        posts_list.setHasFixedSize(true)
        posts_list.layoutManager = LinearLayoutManager(context)

        initAdapter()

        if(savedInstanceState == null){
//            val posts = mutableListOf<MemePostItem>()
//            for(i in 1..10){
//                posts.add(MemePostItem(
//                        "Title $i",
//                        "https://picsum.photos/200/200?image=$i"
//                ))
//            }
//            (posts_list.adapter as PostsAdapter).addPosts(posts)
            requestPosts()
        }
    }

    private fun requestPosts() {
         val subscription = postsManager.getPosts()
                 .subscribeOn(Schedulers.io())
                 .observeOn(AndroidSchedulers.mainThread())
                 .subscribe (
                         { retrievedPosts ->
                             (posts_list.adapter as PostsAdapter).addPosts(retrievedPosts)
                         },
                         { e ->
                             Snackbar.make(posts_list, e.message ?: "", Snackbar.LENGTH_SHORT).show()
                         }
                 )
        subscriptions.add(subscription)
    }

    private fun initAdapter() {
        if(posts_list.adapter == null){
            posts_list.adapter = PostsAdapter()
        }
    }


}// Required empty public constructor
