//HintName: Gqlp_parent-descr+Dual_Intf.gen.cs
// Generated from parent-descr+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Gqlp_parent_descr_Dual;

public interface IPrntDescrDual
  : IRefPrntDescrDual
{
}

public interface IRefPrntDescrDual
{
  Number parent { get; }
  String AsString { get; }
}
