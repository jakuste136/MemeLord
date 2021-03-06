package com.majstehermuskic.memelordmobile.features.displayposts


import android.os.Bundle
import android.support.design.widget.Snackbar
import android.support.v7.widget.LinearLayoutManager
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import com.majstehermuskic.memelordmobile.MemeLordApp
import com.majstehermuskic.memelordmobile.R
import com.majstehermuskic.memelordmobile.commons.InfiniteScrollListener
import com.majstehermuskic.memelordmobile.commons.MemePostItem
import com.majstehermuskic.memelordmobile.commons.MemePosts
import com.majstehermuskic.memelordmobile.commons.RxBaseFragment
import com.majstehermuskic.memelordmobile.commons.extensions.inflate
import com.majstehermuskic.memelordmobile.features.displayposts.adapter.PostsAdapter
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.schedulers.Schedulers
import kotlinx.android.synthetic.main.fragment_posts.*
import javax.inject.Inject


class PostsFragment : RxBaseFragment() {

    companion object {
        private const val KEY_MEME_POSTS = "memePosts"
    }

    @Inject lateinit var postsManager: PostsManager
    private var memePosts: MemePosts? = null
    private var allMemePosts: List<MemePostItem>? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        MemeLordApp.postsComponent.inject(this)
    }

    override fun onCreateView(inflater: LayoutInflater?, container: ViewGroup?,
                              savedInstanceState: Bundle?): View? {
        return container?.inflate(R.layout.fragment_posts)
    }

    override fun onActivityCreated(savedInstanceState: Bundle?) {
        super.onActivityCreated(savedInstanceState)

        posts_list.apply {
            setHasFixedSize(true)
            val linearLayout = LinearLayoutManager(context)
            layoutManager = linearLayout
            clearOnScrollListeners()
            addOnScrollListener(InfiniteScrollListener({requestPosts()}, linearLayout))
        }

        initAdapter()

        if(savedInstanceState != null && savedInstanceState.containsKey(KEY_MEME_POSTS)){
            memePosts = savedInstanceState.get(KEY_MEME_POSTS) as MemePosts
            (posts_list.adapter as PostsAdapter).clearAndAddPosts(memePosts!!.posts)
        } else {
            requestPosts()
        }
    }

    override fun onPause() {
        super.onPause()
        allMemePosts = (posts_list.adapter as PostsAdapter).getPosts()
    }

    override fun onResume() {
        super.onResume()
        if(allMemePosts != null && (posts_list.adapter as PostsAdapter).getPosts().isEmpty()) {
            (posts_list.adapter as PostsAdapter).clearAndAddPosts(allMemePosts!!)
        }
    }

    override fun onSaveInstanceState(outState: Bundle) {
        super.onSaveInstanceState(outState)

        if (posts_list != null) {
            val posts = (posts_list.adapter as PostsAdapter).getPosts()
            if(memePosts != null && posts.isNotEmpty()) {
                outState.putParcelable(KEY_MEME_POSTS, memePosts?.copy(posts = posts))
            }
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
                             Snackbar.make(posts_list, e.message ?: "", Snackbar.LENGTH_LONG).show()
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
