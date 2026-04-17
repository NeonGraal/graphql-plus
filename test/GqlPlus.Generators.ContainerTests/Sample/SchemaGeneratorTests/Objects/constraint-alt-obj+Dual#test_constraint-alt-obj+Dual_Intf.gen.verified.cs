//HintName: test_constraint-alt-obj+Dual_Intf.gen.cs
// Generated from {CurrentDirectory}constraint-alt-obj+Dual.graphql+
//   with GeneratorOption: BaseType: Interface, BaseName: IGqlpInterfaceBase, GeneratorType: Intf
//   and ModelOption: BaseNamespace: Testing, TypePrefix: test, NamespaceIncludesBaseName: True
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_constraint_alt_obj_Dual;

public interface ItestCnstAltObjDual
  : IGqlpInterfaceBase
{
  ItestRefCnstAltObjDual<ItestAltCnstAltObjDual>? AsRefCnstAltObjDual { get; }
  ItestCnstAltObjDualObject? As_CnstAltObjDual { get; }
}

public interface ItestCnstAltObjDualObject
  : IGqlpInterfaceBase
{
}

public interface ItestRefCnstAltObjDual<TRef>
  : IGqlpInterfaceBase
{
  TRef? Asref { get; }
  ItestRefCnstAltObjDualObject<TRef>? As_RefCnstAltObjDual { get; }
}

public interface ItestRefCnstAltObjDualObject<TRef>
  : IGqlpInterfaceBase
{
}

public interface ItestPrntCnstAltObjDual
  : IGqlpInterfaceBase
{
  string? AsString { get; }
  ItestPrntCnstAltObjDualObject? As_PrntCnstAltObjDual { get; }
}

public interface ItestPrntCnstAltObjDualObject
  : IGqlpInterfaceBase
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
