//HintName: test_constraint-alt-obj+Dual_Dec.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Class, BaseName: GqlpDecoderBase, GeneratorType: Dec
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

public interface ItestCnstAltObjDual
  // No Base because it's Class
{
  ItestRefCnstAltObjDual<ItestAltCnstAltObjDual>? AsRefCnstAltObjDual { get; }
  ItestCnstAltObjDualObject? As_CnstAltObjDual { get; }
}

public interface ItestCnstAltObjDualObject
  // No Base because it's Class
{
}

public interface ItestRefCnstAltObjDual<TRef>
  // No Base because it's Class
{
  TRef? Asref { get; }
  ItestRefCnstAltObjDualObject<TRef>? As_RefCnstAltObjDual { get; }
}

public interface ItestRefCnstAltObjDualObject<TRef>
  // No Base because it's Class
{
}

public interface ItestPrntCnstAltObjDual
  // No Base because it's Class
{
  string? AsString { get; }
  ItestPrntCnstAltObjDualObject? As_PrntCnstAltObjDual { get; }
}

public interface ItestPrntCnstAltObjDualObject
  // No Base because it's Class
{
}

public interface ItestAltCnstAltObjDual
  : ItestPrntCnstAltObjDual
{
  ItestAltCnstAltObjDualObject? As_AltCnstAltObjDual { get; }
}

public interface ItestAltCnstAltObjDualObject
  : ItestPrntCnstAltObjDualObject
{
  decimal Alt { get; }
}
