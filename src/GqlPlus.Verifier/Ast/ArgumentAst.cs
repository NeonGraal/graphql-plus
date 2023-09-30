namespace GqlPlus.Verifier.Ast;

internal record class ArgumentAst
{
  internal string? Variable { get; set; }

  //internal ArgumentAst[] Values { get; set; } = Array.Empty<ArgumentAst>();

  //internal IDictionary<FieldKeyAst,ArgumentAst> Fields { get; set; } = new Dictionary<FieldKeyAst,ArgumentAst>();

  //internal ConstantAst? ConstantAst { get; set; }
}
