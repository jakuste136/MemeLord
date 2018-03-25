package com.majstehermuskic.memelordmobile.commons

import android.support.v4.app.Fragment
import io.reactivex.disposables.CompositeDisposable

/**
 * Created by Bartosz on 2018-03-16.
 */
open class RxBaseFragment : Fragment() {

    protected var subscriptions = CompositeDisposable()

    override fun onResume() {
        super.onResume()
        subscriptions = CompositeDisposable()
    }

    override fun onPause() {
        super.onPause()
        if(!subscriptions.isDisposed) {
            subscriptions.dispose()
        }
        subscriptions.clear()
    }
}