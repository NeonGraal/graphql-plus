using GqlPlus.Verifier.Ast.Schema;
using GqlPlus.Verifier.Rendering;

namespace GqlPlus.Verifier.Modelling;

public abstract class TestReferenceModel<TRef>
  : TestModelBase<string>
  where TRef : AstReference<TRef>
{
  //[Theory, RepeatData(Repeats)]
  //public void Model_Fields(string name, FieldInput[] fields)
  //  => ObjectChecks.ObjectExpected(
  //    ObjectChecks.ObjectAst(name, fields, []),
  //    new(name, null, fields));

  //[Theory, RepeatData(Repeats)]
  //public void Model_All(string name, string contents, string parent, string[] aliases, FieldInput[] fields, string[] alternates)
  //  => ObjectChecks.ObjectExpected(
  //    ObjectChecks.ObjectAst(name, fields, alternates) with {
  //      Aliases = aliases,
  //      Description = contents,
  //      Parent = ObjectChecks.ParentAst(parent),
  //    },
  //    new(name, parent, fields, alternates,
  //      [$"aliases: [{string.Join(", ", aliases)}]"],
  //      ["description: " + ObjectChecks.YamlQuoted(contents)]));

  protected override string[] ExpectedBase(string input)
    => ReferenceChecks.ExpectedReference(input);

  internal override ICheckModelBase<string> BaseChecks => ReferenceChecks;

  internal abstract ICheckReferenceModel<TRef> ReferenceChecks { get; }
}

internal abstract class CheckReferenceModel<TRef, TModel>(
  IModeller<TRef, TModel> reference,
  TypeKindModel kind
) : CheckModelBase<string, TRef, TModel>(reference),
    ICheckReferenceModel<TRef>
  where TRef : AstReference<TRef>
  where TModel : IRendering
{
  protected override TRef NewBaseAst(string input)
    => NewReferenceAst(input);

  protected abstract TRef NewReferenceAst(string name);

  void ICheckReferenceModel<TRef>.Reference_Expected(TRef ast, string[] expected)
    => Model_Expected(AstToModel(ast), expected, false);
  void ICheckReferenceModel<TRef>.Reference_Expected(TRef ast, string[] expected, bool skipIf)
    => Model_Expected(AstToModel(ast), expected, skipIf);
  TRef ICheckReferenceModel<TRef>.ReferenceAst(string name)
    => NewReferenceAst(name);
  string[] ICheckReferenceModel<TRef>.ExpectedReference(string input)
    => [$"!_{kind}Base {input}"];
}

internal interface ICheckReferenceModel<TRef>
  : ICheckModelBase<string>
  where TRef : AstReference<TRef>
{
  string[] ExpectedReference(string input);
  void Reference_Expected(TRef ast, string[] expected);
  void Reference_Expected(TRef ast, string[] expected, bool skipIf);
  TRef ReferenceAst(string name);
}
