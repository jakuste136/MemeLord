package com.majstehermuskic.memelordmobile.features.authorization

import okhttp3.Interceptor
import okhttp3.Response



class AuthorizationInterceptor : Interceptor{

    companion object {
        var token: String? = null
    }

    override fun intercept(chain: Interceptor.Chain): Response {
        if(!token.isNullOrEmpty()){
            val originalRequest = chain.request()
            val authorizedRequest = originalRequest.newBuilder()
                    //TODO: Dokończyć headery
                    .header("token", token ?: "")
                    .method(originalRequest.method(), originalRequest.body())
                    .build()
            return chain.proceed(authorizedRequest)
        }
        return chain.proceed(chain.request())
    }
}