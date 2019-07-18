using System;
using Amazon.ComprehendMedical;
using Amazon.Textract;
using Microsoft.Extensions.Configuration;

namespace comprehend_medical_samples {
	class Program {
		static void Main (string[] args) {
			var builder = new ConfigurationBuilder ()
				.SetBasePath (Environment.CurrentDirectory)
				.AddJsonFile ("appsettings.json", optional : false, reloadOnChange : true)
				.Build ();
			var awsOptions = builder.GetAWSOptions ();
			var textractTextService = new TextractTextDetectionService (awsOptions.CreateServiceClient<IAmazonTextract> ());
			var comprehendMedicalService = new ComprehendService (awsOptions.CreateServiceClient<IAmazonComprehendMedical> ());
			var task = textractTextService.DetectTextLocal ("test-files/sample.png");
			task.Wait ();
			var result = task.Result;
			// textractTextService.Print(result);

			var comprehendTask = comprehendMedicalService.DetectEntities (string.Join ("\n", textractTextService.GetLines (result)));
			comprehendTask.Wait ();
			var entities = comprehendTask.Result;
			Console.WriteLine ("==Non-PHI==");
			comprehendMedicalService.Print (entities);

			Console.WriteLine ("==PHI==");
			comprehendTask = comprehendMedicalService.DetectPHI (string.Join ("\n", textractTextService.GetLines (result)));
			comprehendTask.Wait ();
			entities = comprehendTask.Result;
			comprehendMedicalService.Print (entities);
		}

	}
}