using Microsoft.CodeAnalysis;

namespace GqlPlus;

public class CheckTestsGeneratorTests
{
  private readonly VerifySettings _settings = new VerifySettings().CheckAutoVerify();

  private const string Checks = """
    internal class TestChecks : ITestChecks {
      public void Check_Test() { }
      public void Check_Name(string name) { }
      public void Check_Basic(string name) { }
    }
    internal interface ITestChecks : IChecks<string> {
      void Check_Test();
    }
    internal interface IChecks<T> : IChecks {
      void Check_Name(T name);
    }
    internal interface IChecks {
      void Check_Basic(string name);
    }
    """;

  [Fact]
  public Task CheckTestsFor_ExplicitDuplicate()
  {
    string source = """
      using GqlPlus; 
      namespace GqlpPlusTests; 
      [CheckTestsFor(nameof(Checks1), typeof(ITestChecks), Inherited = true)] 
      [CheckTestsFor(nameof(Checks2), typeof(IChecks<string>), Inherited = true)] 
      public class Tests { 
        private TestChecks Checks1 { get; } = new();
        private TestChecks Checks2 { get; } = new();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsForAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTestsFor_ImpliedDuplicate()
  {
    string source = """
      using GqlPlus; 
      namespace GqlpPlusTests; 
      [CheckTestsFor(nameof(Checks1), Inherited = true)] 
      [CheckTestsFor(nameof(Checks2), Inherited = true)] 
      public class Tests { 
        private ITestChecks Checks1 { get; } = new TestChecks();
        private IChecks<string> Checks2 { get; } = new TestChecks();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsForAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTestsFor_ExplicitMultiple()
  {
    string source = """
      using GqlPlus; 
      namespace GqlpPlusTests; 
      [CheckTestsFor(nameof(Checks), typeof(ITestChecks))] 
      [CheckTestsFor(nameof(Checks), typeof(IChecks<string>))] 
      public class Tests { 
        private TestChecks Checks { get; } = new();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsForAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTestsFor_ImpliedMultiple()
  {
    string source = """
      using GqlPlus; 
      namespace GqlpPlusTests; 
      [CheckTestsFor(nameof(Checks))] 
      [CheckTestsFor(nameof(Checks), typeof(IChecks<string>))] 
      public class Tests { 
        private ITestChecks Checks { get; } = new TestChecks();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsForAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTestsFor_ExplicitInherited()
  {
    string source = """
      using GqlPlus; 
      namespace GqlpPlusTests; 
      [CheckTestsFor(nameof(Checks), typeof(ITestChecks), Inherited = true)] 
      public class Tests { 
        private TestChecks Checks { get; } = new();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsForAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTestsFor_ImpliedInherited()
  {
    string source = """
      using GqlPlus; 
      namespace GqlpPlusTests; 
      [CheckTestsFor(nameof(Checks), Inherited = true)] 
      public class Tests { 
        private ITestChecks Checks { get; } = new TestChecks();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsForAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTestsFor_ExplicitGenericType()
  {
    string source = """
      using GqlPlus; 
      namespace GqlpPlusTests; 
      [CheckTestsFor(nameof(Checks), typeof(IChecks<string>))] 
      public class Tests { 
        private TestChecks Checks { get; } = new();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsForAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTestsFor_ImpliedGenericType()
  {
    string source = """
      using GqlPlus; 
      namespace GqlpPlusTests; 
      [CheckTestsFor(nameof(Checks))] 
      public class Tests { 
        private IChecks<string> Checks { get; } = new TestChecks();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsForAttribute));

    return Verifier.Verify(driver, _settings);
  }

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
