## Comprehend Medical Samples

Sample code to start using Amazon Comprehend with C# and Dotnet Core Console
application. This sample uses test files in png and jpg formats that are read by
Amazon Textract for text detection. The detected text is then passed to Amazon
Comprehend that detects Entities and PHI. The detected Entities and PHI are then
printed on screen.

# Amazon Comprehend Medical Samples for .NET Core

.NET Core Samples for
[Amazon Comprehend Medical](https://aws.amazon.com/comprehend/medical/). Amazon
Comprehend Medical is a natural language processing service that makes it easy
to use machine learning to extract relevant medical information from
unstructured text. Using Amazon Comprehend Medical, you can quickly and
accurately gather information, such as medical condition, medication, dosage,
strength, and frequency from a variety of sources like doctors’ notes, clinical
trial reports, and patient health records.

This sample uses a two step process:

- It uses [Amazon Textract](https://aws.amazon.com/textract/) AWS .NET SDK to
  detect text from a PNG file (sample.png) located in test-files/ folder. You
  can use your own PNG or JPG file. Amazon Textract can also read from PDF but
  that is out of scope for this sample, and
- Amazon Comprehend Medical AWS .NET SDK is then used to analyze the detected
  text to detect entities like attributes, categories, and traits, and detect
  PHI information

### Prerequisites

- [Install](https://dotnet.microsoft.com/download) .NET core
- [Install](https://docs.aws.amazon.com/cli/latest/userguide/cli-chap-install.html)
  and
  [Configure](https://docs.aws.amazon.com/cli/latest/userguide/cli-chap-configure.html)
  AWS CLI

## To run the code

Browse the folder where you have cloned/downloaded the project then run the
following

```
dotnet run
```

## Dependencies

The project file (.csproj) of this sample lists all the dependencies

```
<ItemGroup>
    <PackageReference Include="AWSSDK.ComprehendMedical" Version="3.3.100.32" />
    <PackageReference Include="AWSSDK.Extensions.NETCore.Setup" Version="3.3.100.1" />
    <PackageReference Include="AWSSDK.Textract" Version="3.3.101.24" />
    <PackageReference Include="Microsoft.Extensions.Configuration" Version="2.2.0" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="2.2.0" />
</ItemGroup>
```

### Example output

```
==Non-PHI==
12 entities found
Attributes
Categories
   PROTECTED_HEALTH_INFORMATION:0.9932775:Unicorn Smith
Traits
Attributes
Categories
   PROTECTED_HEALTH_INFORMATION:0.9966829:Unicorn Smith
Traits
Attributes
Categories
   PROTECTED_HEALTH_INFORMATION:0.9953083:Unicorn Smith
Traits
Attributes
Categories
   PROTECTED_HEALTH_INFORMATION:0.9998387:January 32, 1901
Traits
Attributes
Categories
   PROTECTED_HEALTH_INFORMATION:0.76162:Captain Marvel
Traits
Attributes
Categories
   PROTECTED_HEALTH_INFORMATION:0.2977315:Stark Towers
Traits
Attributes
Categories
   MEDICAL_CONDITION:0.9962941:Nausea
Traits
  SYMPTOM:0.8347825
Attributes
Categories
   MEDICAL_CONDITION:0.9984876:vomiting
Traits
  SYMPTOM:0.8194339
Attributes
Categories
   MEDICAL_CONDITION:0.9421097:high fever
Traits
  SYMPTOM:0.7858275
Attributes
Categories
   MEDICAL_CONDITION:0.3872434:Suicide
Traits
Attributes
   DOSAGE:0.9819972:200 mg
   FREQUENCY:0.9816223:3 times a day
   DURATION:0.9941246:10 days
Categories
   MEDICATION:0.9929543:Ibuprofen
Traits
Attributes
   DOSAGE:0.9688048:150 mg
   FREQUENCY:0.9989164:twice daily
Categories
   MEDICATION:0.9990332:Ranitidine
Traits
==PHI==
6 entities found
Attributes
Categories
   PROTECTED_HEALTH_INFORMATION:0.9932775:Unicorn Smith
Traits
Attributes
Categories
   PROTECTED_HEALTH_INFORMATION:0.9966829:Unicorn Smith
Traits
Attributes
Categories
   PROTECTED_HEALTH_INFORMATION:0.9953083:Unicorn Smith
Traits
Attributes
Categories
   PROTECTED_HEALTH_INFORMATION:0.9998387:January 32, 1901
Traits
Attributes
Categories
   PROTECTED_HEALTH_INFORMATION:0.76162:Captain Marvel
Traits
Attributes
Categories
   PROTECTED_HEALTH_INFORMATION:0.2977315:Stark Towers
Traits
```

## License Summary

This sample code is made available under the MIT-0 license. See the LICENSE
file.
