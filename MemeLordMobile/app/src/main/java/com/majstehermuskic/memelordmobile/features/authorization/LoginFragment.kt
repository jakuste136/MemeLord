package com.majstehermuskic.memelordmobile.features.authorization

import android.app.Fragment
import android.os.Bundle
import android.support.design.widget.Snackbar
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import com.majstehermuskic.memelordmobile.MainActivity
import com.majstehermuskic.memelordmobile.MemeLordApp
import com.majstehermuskic.memelordmobile.R
import com.majstehermuskic.memelordmobile.api.LoginAPI
import com.majstehermuskic.memelordmobile.api.LoginResponse
import com.majstehermuskic.memelordmobile.commons.RxBaseFragment
import com.majstehermuskic.memelordmobile.commons.extensions.inflate
import kotlinx.android.synthetic.main.activity_main.*
import kotlinx.android.synthetic.main.content_main.*
import kotlinx.android.synthetic.main.fragment_login.*
import retrofit2.Call
import retrofit2.Callback
import retrofit2.Response
import javax.inject.Inject

class LoginFragment : RxBaseFragment() {

    @Inject
    lateinit var api: LoginAPI

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

        val callResponse = api.login(editUsername.text.toString(), editPassword.text.toString())
        callResponse.enqueue(object: Callback<LoginResponse>{
                    override fun onResponse(call: Call<LoginResponse>?, response: Response<LoginResponse>?) {
                        if (response?.code() == 200) {
                            AuthorizationInterceptor.token = response.body()?.access_token ?: ""
                            fragmentManager.popBackStack()
                        } else {
                            Toast.makeText(context, "Wrong password!!!", Toast.LENGTH_LONG).show()
                        }
                    }

                    override fun onFailure(call: Call<LoginResponse>?, t: Throwable?) {
                        Snackbar.make(buttonLogin, t?.message ?: "", Snackbar.LENGTH_LONG).show()
                    }

                }
        )
    }

}// Required empty public constructor