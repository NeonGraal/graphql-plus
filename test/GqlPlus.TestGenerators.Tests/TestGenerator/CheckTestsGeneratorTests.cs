using Microsoft.CodeAnalysis;

namespace GqlPlus.TestGenerator;

public class CheckTestsGeneratorTests
{
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
    internal interface ITestChecks : IChecksString {
      string Label { get; }
      void Check_Test();
    }
    internal interface IChecksString : IChecks<string> {
    }
    internal interface IChecks<T> : IChecks {
      void Check_Name(T name);
    }
    internal interface IChecks {
      void Check_Basic(string name);
    }
    """;

  [Fact]
  public Task CheckTests_ExplicitSkipEmptyInterface()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      public class Tests {
        [CheckTests(typeof(IChecksString))]
        private TestChecks Checks { get; } = new();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsAttribute));

    return driver.AttachAndVerify();
  }

  [Fact]
  public Task CheckTests_ImpliedSkipEmptyInterface()
  {
    string source = """
      using GqlPlus;
      namespace GqlpPlusTests;
      public class Tests {
        [CheckTests]
        private IChecksString Checks { get; } = new TestChecks();
      }
      """ + Checks;

    GeneratorDriver driver = new CheckTestsGenerator()
      .Generate(source, typeof(CheckTestsAttribute));

    return driver.AttachAndVerify();
  }

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

    return driver.AttachAndVerify();
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

    return driver.AttachAndVerify();
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

    return driver.AttachAndVerify();
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

    return driver.AttachAndVerify();
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

    return driver.AttachAndVerify();
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

    return driver.AttachAndVerify();
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

    return driver.AttachAndVerify();
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

    return driver.AttachAndVerify();
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

    return driver.AttachAndVerify();
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

    return driver.AttachAndVerify();
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

    return driver.AttachAndVerify();
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

    return driver.AttachAndVerify();
  }
}
