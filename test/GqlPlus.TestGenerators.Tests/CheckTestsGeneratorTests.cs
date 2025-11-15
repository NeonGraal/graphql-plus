using Microsoft.CodeAnalysis;

namespace GqlPlus;

public class CheckTestsGeneratorTests
{
  private readonly VerifySettings _settings = new VerifySettings().CheckAutoVerify();

  private const string Checks = """
    internal class TestChecks : IChecks { }
    internal interface IChecks {
      void Check_Name(string name);
    }
    """;

  [Fact]
  public Task CheckTestsFor_ImpliedType()
  {
    string source = """
      using GqlPlus; 
      namespace GqlpPlusTests; 
      [CheckTestsFor(nameof(Checks))] 
      public class Tests { 
        private IChecks Checks { get; } = new TestChecks();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsForAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTestsFor_ExplicitType()
  {
    string source = """
      using GqlPlus; 
      namespace GqlpPlusTests; 
      [CheckTestsFor(nameof(Checks), typeof(IChecks))] 
      public class Tests { 
        private TestChecks Checks { get; } = new();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsForAttribute));

    return Verifier.Verify(driver, _settings);
  }
}
