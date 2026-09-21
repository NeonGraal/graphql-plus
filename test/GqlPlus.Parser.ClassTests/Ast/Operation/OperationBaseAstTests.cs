namespace GqlPlus.Ast.Operation;

public class OperationBaseAstTests
{
  [Fact]
  public void Initial_Lists_Empty()
  {
    IAstOperationBase ast = CreateOperationBase();

    ast.ShouldSatisfyAllConditions(
      a => a.Argument.ShouldBeNull(),
      a => a.Fragments.ShouldBeEmpty(),
      a => a.Selections.ShouldBeEmpty(),
      a => a.Variables.ShouldBeEmpty()
      );
  }

  [Theory, RepeatData]
  public void SelectionFields_WithSubSelections_ReturnsCorrectStrings(string prefix, string field, string selection)
  {
    OperationBaseAst baseAst = CreateOperationBase();
    IAstSelection selectionAst = new FieldAst(AstNulls.At, selection);
    IAstSelection fieldAst = new FieldAst(AstNulls.At, field) { Selections = [selectionAst] };
    baseAst.SetSelections([fieldAst], prefix);
    string?[] expected = ["{", $"{prefix}: [ ( !f {field} ) ]", $"{prefix}.1: [ ( !f {selection} ) ]", "}"];

    string?[] result = [.. baseAst.SelectionsFields()];

    result.ShouldBe(expected);
  }

  [Theory, RepeatData]
  public void SetSelections_WithSubSelections_SetsCorrectSelections(string prefix, string field, string selection)
  {
    OperationBaseAst baseAst = CreateOperationBase();
    IAstSelection selectionAst = new FieldAst(AstNulls.At, selection);
    IAstSelection fieldAst = new FieldAst(AstNulls.At, field) { Selections = [selectionAst] };

    baseAst.SetSelections([fieldAst], prefix);

    baseAst.Selections.ShouldSatisfyAllConditions(
      a => a.ShouldContainKey(prefix),
      a => a[prefix].ShouldBeEquivalentTo(new[] { fieldAst }),
      a => a.ShouldContainKey(prefix + ".1"),
      a => a[prefix + ".1"].ShouldBeEquivalentTo(new[] { selectionAst })
    );
  }

  [Theory, RepeatData]
  public void SetFragment_WithSelections_SetsCorrectSelections(string fragment, string onType, string field)
  {
    OperationBaseAst baseAst = CreateOperationBase();
    IAstSelection fieldAst = new FieldAst(AstNulls.At, field);
    IAstFragment fragmentAst = new FragmentAst(AstNulls.At, fragment, onType, fieldAst);

    baseAst.SetFragments([fragmentAst]);

    baseAst.Selections.ShouldSatisfyAllConditions(
      a => a.ShouldContainKey(fragment),
      a => a[fragment].ShouldBeEquivalentTo(new[] { fieldAst })
    );
  }

  internal static OperationBaseAst CreateOperationBase()
    => new();
}
