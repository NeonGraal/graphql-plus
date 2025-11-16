using Microsoft.CodeAnalysis;

namespace GqlPlus;

public class CheckTestsGeneratorTests
{
  private readonly VerifySettings _settings = new VerifySettings().CheckAutoVerify();

  private const string Checks = """
    internal class TestChecks : ITestChecks {
      public string Label => "Test";
      public void Check_Test() { }
      public void Check_Name(string name) { }
      public void Check_Basic(string name) { }
    }
    internal class TestChecks<TInput> : IChecks<TInput> {
      public void Check_Name(TInput name) { }
      public void Check_Basic(TInput name) { }
    }
    internal interface ITestChecks : IChecks<string> {
      string Label { get; }
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
  public Task CheckTests_ExplicitGenericClass()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      public class Tests<TInput> {
        [CheckTests(typeof(IChecks<>))]
        private TestChecks<TInput> Checks { get; } = new();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTests_ImpliedGenericClass()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      public class Tests<TInput> {
        [CheckTests]
        private IChecks<TInput> Checks { get; } = new TestChecks<TInput>();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTests_ExplicitDuplicate()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      public class Tests {
        [CheckTests(typeof(ITestChecks), Inherited = true)]
        private TestChecks Checks1 { get; } = new();

        [CheckTests(typeof(IChecks<string>), Inherited = true)]
        private TestChecks Checks2 { get; } = new();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTests_ImpliedDuplicate()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      public class Tests {
        [CheckTests(Inherited = true)]
        private ITestChecks Checks1 { get; } = new TestChecks();
        [CheckTests(Inherited = true)]
        private IChecks<string> Checks2 { get; } = new TestChecks();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTests_ExplicitMultiple()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      public class Tests {
        [CheckTests(typeof(ITestChecks))]
        [CheckTests(typeof(IChecks<string>))]
        private TestChecks Checks { get; } = new();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTests_ImpliedMultiple()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      public class Tests {
        [CheckTests]
        [CheckTests(typeof(IChecks<string>))]
        private ITestChecks Checks { get; } = new TestChecks();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTests_ExplicitInherited()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      public class Tests {
        [CheckTests(typeof(ITestChecks), Inherited = true)]
        private TestChecks Checks { get; } = new();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTests_ImpliedInherited()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      public class Tests {
        [CheckTests(Inherited = true)]
        private ITestChecks Checks { get; } = new TestChecks();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTests_ExplicitGenericType()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      public class Tests {
        [CheckTests(typeof(IChecks<string>))]
        private TestChecks Checks { get; } = new();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTests_ImpliedGenericType()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      public class Tests {
        [CheckTests]
        private IChecks<string> Checks { get; } = new TestChecks();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTests_ImpliedType()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      public class Tests {
        [CheckTests]
        private IChecks Checks { get; } = new TestChecks();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTests_ExplicitType()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      public class Tests {
        [CheckTests(typeof(IChecks))]
        private TestChecks Checks { get; } = new();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTestsFor_ExplicitGenericClass()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      [CheckTestsFor(nameof(Checks), typeof(IChecks<>))]
      public class Tests<TInput> {
        private TestChecks<TInput> Checks { get; } = new();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsForAttribute));

    return Verifier.Verify(driver, _settings);
  }

  [Fact]
  public Task CheckTestsFor_ImpliedGenericClass()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      [CheckTestsFor(nameof(Checks))]
      public class Tests<TInput> {
        private IChecks<TInput> Checks { get; } = new TestChecks<TInput>();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsForAttribute));

    return Verifier.Verify(driver, _settings);
  }

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
