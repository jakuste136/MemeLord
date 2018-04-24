package com.majstehermuskic.memelordmobile.features.authorization

import com.majstehermuskic.memelordmobile.api.LoginAPI
import io.reactivex.Observable
import javax.inject.Inject
import javax.inject.Singleton

@Singleton
class LoginManager @Inject constructor(private val api: LoginAPI) {

    fun login(username: String, password: String): Observable<String> {
        return Observable.create {
            subscriber ->
            val callResponse = api.login(username, password)
            val response = callResponse.execute()

            if(response.isSuccessful) {
                val loginResponse = response.body()
                val token = loginResponse!!.accessToken

                subscriber.onNext(token)
                subscriber.onComplete()
            } else {
                subscriber.onError(Throwable(response.message()))
            }
        }
    }

}