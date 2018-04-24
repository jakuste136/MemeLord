package com.majstehermuskic.memelordmobile.features.authorization

import android.os.Bundle
import android.support.design.widget.Snackbar
import android.support.v7.widget.LinearLayoutManager
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import com.majstehermuskic.memelordmobile.MemeLordApp
import com.majstehermuskic.memelordmobile.R
import com.majstehermuskic.memelordmobile.commons.InfiniteScrollListener
import com.majstehermuskic.memelordmobile.commons.MemePosts
import com.majstehermuskic.memelordmobile.commons.RxBaseFragment
import com.majstehermuskic.memelordmobile.commons.extensions.inflate
import com.majstehermuskic.memelordmobile.features.posts.PostsManager
import com.majstehermuskic.memelordmobile.features.posts.adapter.PostsAdapter
import io.reactivex.android.schedulers.AndroidSchedulers
import io.reactivex.schedulers.Schedulers
import kotlinx.android.synthetic.main.fragment_login.*
import kotlinx.android.synthetic.main.fragment_posts.*
import javax.inject.Inject

class LoginFragment : RxBaseFragment() {

    @Inject
    lateinit var loginManager: LoginManager

    var token: String? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        MemeLordApp.loginComponent.inject(this)
    }

    override fun onCreateView(inflater: LayoutInflater?, container: ViewGroup?,
                              savedInstanceState: Bundle?): View? {
        return container?.inflate(R.layout.fragment_login)
    }

    override fun onActivityCreated(savedInstanceState: Bundle?) {
        super.onActivityCreated(savedInstanceState)

        buttonLogin.setOnClickListener {
            login()
        }
    }

    private fun login() {
//        val subscription = loginManager.login(editUsername.text.toString(), editPassword.text.toString())
//                .subscribeOn(Schedulers.io())
//                .observeOn(AndroidSchedulers.mainThread())
//                .subscribe (
//                        {
//                            token = it
//                        },
//                        { e ->
//                            Snackbar.make(posts_list, e.message ?: "", Snackbar.LENGTH_LONG).show()
//                        }
//                )
//        subscriptions.add(subscription)
    }

}// Required empty public constructor