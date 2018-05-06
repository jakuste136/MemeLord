package com.majstehermuskic.memelordmobile.api

import retrofit2.Call
import javax.inject.Inject

class LoginRestAPI @Inject constructor(private val memeLordApi:MemeLordAPI): LoginAPI {
    override fun login(username: String, password: String): Call<LoginResponse> {
        return memeLordApi.login(username,password)
    }
}