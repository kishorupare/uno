﻿using NUnit.Framework;
using Uno.UITest;
using Uno.UITest.Helpers;
using Uno.UITest.Helpers.Queries;

namespace SamplesApp.UITests
{
	public class SampleControlUITestBase
	{
		protected IApp _app;
		protected Platform? _platform;

		public SampleControlUITestBase()
		{
		}

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			_app = AppInitializer.StartApp();

			Helpers.App = _app;
		}

		public SampleControlUITestBase(Platform platform) : this()
		{
			_platform = platform;
		}

		[SetUp]
		public void BeforeEachTest()
		{
			// Check if the test needs to be ignore or not
			// If nothing specified, it is considered as a global test
			if(_platform == null)
			{
				return;
			}

			// Otherwise, we need to define on which platform the test is running and compare it with targeted platform
			var shouldIgnore = false;
			var currentPlatform = AppInitializer.GetLocalPlatform();

			if (_app is Uno.UITest.Xamarin.XamarinApp xa)
			{
				if (Xamarin.UITest.TestEnvironment.Platform == Xamarin.UITest.TestPlatform.Local)
				{
					shouldIgnore = currentPlatform != _platform;
				}
				else
				{
					var testCloudPlatform = Xamarin.UITest.TestEnvironment.Platform == Xamarin.UITest.TestPlatform.TestCloudiOS
						? Platform.iOS
						: Platform.Android;

					shouldIgnore = _platform != testCloudPlatform;
				}
			}
			else
			{
				shouldIgnore = _platform != currentPlatform;
			}

			if (shouldIgnore)
			{
				Assert.Ignore("This test is ignored on this platform");
			}
		}

		[OneTimeTearDown]
		public void CloseBrowser()
			=> _app.Dispose();

		protected void Run(string metadataName)
		{
			_app.WaitForElement("sampleControl");

			var testRunId = _app.InvokeGeneric("browser:SampleRunner|RunTest", metadataName);

			_app.WaitFor(() =>
			{
				var result = _app.InvokeGeneric("browser:SampleRunner|IsTestDone", testRunId).ToString();
				return bool.TryParse(result, out var testDone) && testDone;
			});

			_app.Screenshot(metadataName.Replace(".", "_"));
		}
	}
}
