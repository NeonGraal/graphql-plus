using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract class ModelScalarTests<TInput>
  : ModelAliasedTests<string>
{
  protected IEnumerable<string> Items(TInput[] inputs)
    => Items(inputs, ExpectedItem()).Prepend("items:");

  protected IEnumerable<string> AllItems(TInput[] inputs, string ofScalar)
    => Items(inputs, ExpectedAllItem(ofScalar)).Prepend("allItems:");

  protected abstract string[] ExpectedItem(TInput input, string exclude, string[] scalar);

  private IEnumerable<string> Items(TInput[] inputs, Func<TInput, bool, IEnumerable<string>> mapping)
  {
    var exclude = true;

    return inputs.SelectMany(i => mapping(i, exclude = !exclude));
  }

  private Func<TInput, bool, IEnumerable<string>> ExpectedItem()
    => (input, exclude) => ExpectedItem(input, "  exclude: " + exclude.TrueFalse(), []);

  private Func<TInput, bool, IEnumerable<string>> ExpectedAllItem(string ofScalar)
        => (input, exclude) => {
          var result = ExpectedItem(input, "  exclude: " + exclude.TrueFalse(), ["  scalar: " + ofScalar]);
          return ["- !_ScalarItem(" + result[0][3..] + ")", .. result[1..]];
        };
}
