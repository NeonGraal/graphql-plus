﻿//HintName: Model_Intro_Common.gen.cs
// Generated from Intro_Common.graphql+
/*
output _Type {
    | _BaseType<_TypeKind.Basic>
    | _BaseType<_TypeKind.Internal>
    | _TypeDual
    | _TypeEnum
    | _TypeInput
    | _TypeOutput
    | _TypeDomain
    | _TypeUnion
    }
output _BaseType<$kind> {
    : _Aliased
        typeKind: $kind
    }
output _ChildType<$kind $parent> {
    : _BaseType<$kind>
        parent: $parent
    }
output _ParentType<$kind $item $allItem> {
    : _ChildType<$kind _Identifier>
        items: $item[]
        allItems: $allItem[]
    }
enum _SimpleKind { Basic Enum Internal Domain Union }
enum _TypeKind { :_SimpleKind Dual Input Output }
output _TypeRef<$kind> {
        typeKind: $kind
        name: _Identifier
}
output _TypeSimple {
    | _TypeRef<_TypeKind.Basic>
    | _TypeRef<_TypeKind.Enum>
    | _TypeRef<_TypeKind.Domain>
    | _TypeRef<_TypeKind.Union>
    }
*/
namespace GqlPlus;
public class Model_Intro_Common {}