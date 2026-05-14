using GqlPlus.Generating;

namespace GqlPlus.Generating;

public class GeneratorTests
  : GenerateClassTestsBase
{
  [Fact]
  internal void Generate_WhenCalled_DelegatesToValue()
  {
    IGenerator<IAstError> inner = GFor<IAstError>();
    IAstError ast = A.Of<IAstError>();
    GqlpGeneratorContext context = Context();

    Generator<IAstError> generator = new(() => inner);

    generator.Generate(ast, context);

    inner.Received(1).Generate(ast, context);
  }

  [Fact]
  internal void ImplicitConvert_FromDelegate_ReturnsGenerator()
  {
    IGenerator<IAstError> inner = GFor<IAstError>();
    IAstError ast = A.Of<IAstError>();
    GqlpGeneratorContext context = Context();

    Generator<IAstError>.D factory = () => inner;
    Generator<IAstError> result = factory;

    result.Generate(ast, context);

    inner.Received(1).Generate(ast, context);
  }

  [Fact]
  internal void ImplicitConvert_NullFactory_ThrowsArgumentNullException()
  {
    Generator<IAstError>.D? factory = null;

    Action result = () => _ = (Generator<IAstError>)factory!;

    result.ShouldThrow<ArgumentNullException>();
  }
}
