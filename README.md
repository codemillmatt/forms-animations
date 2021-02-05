# Animating Xamarin.Forms

Animations make your app visually appealing, easier to use, and more engaging.

Animations however are not limited to only traditional Xamarin development; you can add beautiful animations to Xamarin.Forms.

In this session, you will learn the core concepts of when to use animations in a mobile app and explore several different frameworks used to create them.

When to properly use animations to provide visual feedback, supply context around UI elements, and call attention to app status changes will be explored. Then you’ll learn how to make your app come to life using the built-in Xamarin.Forms animation APIs, SkiaSharp, and the new Lottie animation framework from Airbnb.

After this session, you’ll be equipped to create Xamarin.Forms apps that will stand out with animations.

## Slides

[You can find them here](https://www.slideshare.net/MatthewSoucoup)

## Demos

### Built-in Xamarin.Forms Animation APIs

In this demo we looked at the basics of the built-in Xamarin.Forms animation framework. We explored how to move any type of `View` around, including complex `ContentView`s that are composed of several other controls.

We also looked at `Easing` functions, or functions that control _how_ the view animates on the screen.

### SkiaSharp

This demo showed how to animate using SkiaSharp 2D drawing framework. The key here is to call the `SKCanvas` invalidate funcation then clear what is on the screen and then repaint whatever you need to in such a way that it is just a bit differently - thus appearing as an animation.

### Lottie

Lottie is a framework from Airbnb used to display animations created in After Effects within a mobile app. Thanks to the work of [Martijn van Dijk](https://github.com/martijn00/LottieXamarin) the use of Lottie within a Xamarin.Forms project is as simple as using an image.

## References

### Research
* [Built-in Xamarin.Forms Animation Overview](https://developer.xamarin.com/guides/xamarin-forms/user-interface/animation/simple/)
* [SkiaSharp in Xamarin.Forms](https://developer.xamarin.com/guides/xamarin-forms/advanced/skiasharp/)
* [Petzhold on SkiaSharp](https://channel9.msdn.com/Events/Xamarin/Xamarin-University-Presents-Webinar-Series/SkiaSharp-Graphics-for-XamarinForms?WT.mc_id=mobile-0000-masoucou)
* [Google Material Motion](https://material.io/guidelines/motion/material-motion.html#)
* [Improving Mobile App Experience with Animations](https://www.shopify.com/partners/blog/using-animation-to-improve-mobile-app-user-experience)
* [UX Design with Animations](https://uxplanet.org/animation-in-mobile-ux-design-93263dc6c5f4)

### Slide Images

* Lyft app
* 1Password app
* Shazam app
* Google Calendar app
* Gmail app
* Twitter app
* [Google material motion images](https://material.io/guidelines/motion/material-motion.html#)