#POKKT SDK Unity Integration Guide (v 6.0)









minSdkVersion supported is 11 .

In the iOS package downloaded above you will find:

1. Docs:






We will be referencing PokktAds Demo app provided with SDK . We will be referencing this app during the course of explanation in this document. We suggest you go through the sample app for better understanding.


### Dependencies




~~~
~~~



~~~
~~~










~~~
~~~

~~~

##Project Configuration (iOS)


~~~
~~~

~~~
</dict>
~~~

###Setting Extension (Android)

1. You need to set extension before calling any method like below. This should be the first

###Setting Extension (iOS)

1. You need to set extension before calling any method like below. This should be the first call.


###Common Configuration Steps	




	






	

	

	






	`PokktAds.Interstitial.CacheNonRewarded(“<ScreeName>”);`


	

	


~~~

~~~

PokktAds.Banner.LoadBannerWithRect(<ScreenName>,<Height>, Width>, <x>,<y>);
~~~

####3. Remove Banner

####4. Auto refresh Banner



~~~
~~~

~~~
~~~

~~~
~~~



~~~
~~~



	~~~
	~~~

	~~~
	~~~


	~~~
	~~~

	~~~
	~~~

	~~~
	~~~

	~~~
	~~~

	~~~
	~~~

	~~~
	~~~


	~~~
	~~~
	

	~~~
	~~~
	

~~~
~~~








~~~
~~~


~~~
~~~


~~~
~~~


~~~
~~~


~~~
~~~