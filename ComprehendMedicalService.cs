using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.ComprehendMedical;
using Amazon.ComprehendMedical.Model;

namespace comprehend_medical_samples {
	public class ComprehendService {
		private IAmazonComprehendMedical comprehend { get; }
		private IAmazonComprehendMedical comprehendMedical { get; }

		public ComprehendService (IAmazonComprehendMedical comprehend) {
			this.comprehendMedical = comprehend;
		}

		public async Task<List<Entity>> DetectEntities (string text) {
			var task = await this.comprehendMedical.DetectEntitiesAsync (new DetectEntitiesRequest {
				Text = text
			});
			return task.Entities;
		}
		public async Task<List<Entity>> DetectPHI (string text) {
			var task = await this.comprehendMedical.DetectPHIAsync (new DetectPHIRequest {
				Text = text
			});
			return task.Entities;
		}

		public void Print (List<Entity> entities) {
			Console.WriteLine ("{0} entities found", entities.Count);
			entities.ForEach (entity => {
				Console.WriteLine ("Attributes");
				entity.Attributes.ForEach (attr => Console.WriteLine ("   {0}:{1}:{2}", attr.Type, attr.Score, attr.Text));
				Console.WriteLine ("Categories");
				Console.WriteLine ("   {0}:{1}:{2}", entity.Category, entity.Score, entity.Text);
				Console.WriteLine ("Traits");
				entity.Traits.ForEach (trait => Console.WriteLine ("  {0}:{1}", trait.Name, trait.Score));
			});
		}

	}
}