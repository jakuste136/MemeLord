package com.majstehermuskic.memelordmobile.api

import retrofit2.Call

interface LoginAPI {
    fun login(username: String, password: String): Call<LoginResponse>
}