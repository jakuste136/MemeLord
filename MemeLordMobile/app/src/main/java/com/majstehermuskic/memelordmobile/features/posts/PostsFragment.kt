package com.majstehermuskic.memelordmobile.features.posts


import android.os.Bundle
import android.support.design.widget.Snackbar
import android.support.v4.app.Fragment
import android.support.v7.widget.LinearLayoutManager
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import com.majstehermuskic.memelordmobile.R
import com.majstehermuskic.memelordmobile.commons.InfiniteScrollListener
import com.majstehermuskic.memelordmobile.commons.MemePosts
import com.majstehermuskic.memelordmobile.commons.RxBaseFragment
import com.majstehermuskic.memelordmobile.commons.extensions.inflate
import com.majstehermuskic.memelordmobile.features.posts.adapter.PostsAdapter
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.schedulers.Schedulers
import kotlinx.android.synthetic.main.fragment_posts.*


class PostsFragment : RxBaseFragment() {

    private var memePosts: MemePosts? = null
    private val postsManager by lazy { PostsManager() }

    override fun onCreateView(inflater: LayoutInflater?, container: ViewGroup?,
                              savedInstanceState: Bundle?): View? {
        return container?.inflate(R.layout.fragment_posts)
    }

    override fun onActivityCreated(savedInstanceState: Bundle?) {
        super.onActivityCreated(savedInstanceState)

        posts_list.setHasFixedSize(true)
        val linearLayout = LinearLayoutManager(context)
        posts_list.layoutManager = linearLayout
        posts_list.clearOnScrollListeners()
        posts_list.addOnScrollListener(InfiniteScrollListener({requestPosts()}, linearLayout))

        initAdapter()

        if(savedInstanceState == null){
            requestPosts()
        }
    }

    private fun requestPosts() {
         val subscription = postsManager.getPosts(memePosts?.lastId ?: 0)
                 .subscribeOn(Schedulers.io())
                 .observeOn(AndroidSchedulers.mainThread())
                 .subscribe (
                         { retrievedPosts ->
                             memePosts = retrievedPosts
                             (posts_list.adapter as PostsAdapter).addPosts(retrievedPosts.posts)
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
