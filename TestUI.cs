/*using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace NueralNetrwork
{
    [TestClass]
    class TestUI
    {

        private Activity mActivity;
        private RadioGroup mRadioGroup;
    public static final ActivityTestRule<NetworkActivity> activityTestRule =
            new ActivityTestRule<>(NetworkActivity.class);
    public void setup()
        {
            mActivity = activityTestRule.getActivity();
            mRadioGroup = (RadioGroup)mActivity.findViewById(R.id.radioButtonBackProp);
        }
        [TestMethod]
        public void validateEditText() throws IOException
        {
            onView(withId(R.id.textView)).check(matches(isDisplayed()));
    }

    [TestMethod]
    public void test_visibility()
    {
        Espresso.onView(ViewMatchers.withId(R.id.radioButtonBackProp))
                .check(ViewAssertions.matches(ViewMatchers.isDisplayed()));

        Espresso.onView(ViewMatchers.withId(R.id.radioButtonIpprop))
                .check(ViewAssertions.matches(ViewMatchers.isDisplayed()));

        Espresso.onView(ViewMatchers.withId(R.id.radioButtonRprop))
                .check(ViewAssertions.matches(ViewMatchers.isDisplayed()));

        Espresso.onView(ViewMatchers.withId(R.id.textView))
                .check(ViewAssertions.matches(ViewMatchers.isDisplayed()));

        Espresso.onView(ViewMatchers.withId(R.id.upload))
                .check(ViewAssertions.matches(ViewMatchers.isDisplayed()));

    }
    [TestMethod]
    public void test_isVisibility()
    {
        onView(withId(R.id.radio))
                .check(matches(isDisplayed()));

        onView(withId(R.id.split_action_bar))
                .check(matches(isDisplayed()));

        onView(withId(R.id.textView))
                .check(matches(isDisplayed()));

    }
}
}*/