//HintName: test_constraint-field-obj+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-field-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpModelImplementationBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_field_obj_Dual;

public interface ItestCnstFieldObjDual
  : ItestRefCnstFieldObjDual<ItestAltCnstFieldObjDual>
{
  ItestCnstFieldObjDualObject? As_CnstFieldObjDual { get; }
}

public interface ItestCnstFieldObjDualObject
  : ItestRefCnstFieldObjDualObject<ItestAltCnstFieldObjDual>
{
}

public interface ItestRefCnstFieldObjDual<TRef>
  : IGqlpModelImplementationBase
{
  ItestRefCnstFieldObjDualObject<TRef>? As_RefCnstFieldObjDual { get; }
}

public interface ItestRefCnstFieldObjDualObject<TRef>
  : IGqlpModelImplementationBase
{
  TRef Field { get; }
}

public interface ItestPrntCnstFieldObjDual
  : IGqlpModelImplementationBase
{
  string? AsString { get; }
  ItestPrntCnstFieldObjDualObject? As_PrntCnstFieldObjDual { get; }
}

public interface ItestPrntCnstFieldObjDualObject
  : IGqlpModelImplementationBase
{
}

public interface ItestAltCnstFieldObjDual
  : ItestPrntCnstFieldObjDual
{
  ItestAltCnstFieldObjDualObject? As_AltCnstFieldObjDual { get; }
}

public interface ItestAltCnstFieldObjDualObject
  : ItestPrntCnstFieldObjDualObject
{
  decimal Alt { get; }
}
