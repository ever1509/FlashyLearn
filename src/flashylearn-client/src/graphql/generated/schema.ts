import { gql } from '@apollo/client';
import * as Apollo from '@apollo/client';
export type Maybe<T> = T | null;
export type InputMaybe<T> = Maybe<T>;
export type Exact<T extends { [key: string]: unknown }> = { [K in keyof T]: T[K] };
export type MakeOptional<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]?: Maybe<T[SubKey]> };
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]: Maybe<T[SubKey]> };
const defaultOptions = {} as const;
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: string;
  String: string;
  Boolean: boolean;
  Int: number;
  Float: number;
  UUID: any;
};

export type CategoryDto = {
  __typename?: 'CategoryDto';
  categoryID: Scalars['UUID'];
  name: Scalars['String'];
};

export type CategoryDtoFilterInput = {
  and?: InputMaybe<Array<CategoryDtoFilterInput>>;
  categoryID?: InputMaybe<UuidOperationFilterInput>;
  name?: InputMaybe<StringOperationFilterInput>;
  or?: InputMaybe<Array<CategoryDtoFilterInput>>;
};

export type CategoryResponseDto = {
  __typename?: 'CategoryResponseDto';
  categoryId: Scalars['UUID'];
  name: Scalars['String'];
};

export type CreateCategoryCommandInput = {
  name: Scalars['String'];
  userId?: InputMaybe<Scalars['String']>;
};

export type CreateFlashCardCommandInput = {
  backText: Scalars['String'];
  categoryID: Scalars['String'];
  frontText: Scalars['String'];
};

export type DeleteCategoryCommandInput = {
  id: Scalars['String'];
};

export type DeleteFlashCardInput = {
  id: Scalars['String'];
};

export type FlashCardDto = {
  __typename?: 'FlashCardDto';
  backText: Scalars['String'];
  categoryId: Scalars['String'];
  frontText: Scalars['String'];
};

export type FlashCardDtoFilterInput = {
  and?: InputMaybe<Array<FlashCardDtoFilterInput>>;
  backText?: InputMaybe<StringOperationFilterInput>;
  categoryId?: InputMaybe<StringOperationFilterInput>;
  frontText?: InputMaybe<StringOperationFilterInput>;
  or?: InputMaybe<Array<FlashCardDtoFilterInput>>;
};

export type FlashCardResponseDto = {
  __typename?: 'FlashCardResponseDto';
  backText: Scalars['String'];
  flashCardId: Scalars['UUID'];
  frontText: Scalars['String'];
};

export enum Frequency {
  Daily = 'DAILY',
  Monthly = 'MONTHLY',
  Weekly = 'WEEKLY'
}

export type IntOperationFilterInput = {
  eq?: InputMaybe<Scalars['Int']>;
  gt?: InputMaybe<Scalars['Int']>;
  gte?: InputMaybe<Scalars['Int']>;
  in?: InputMaybe<Array<InputMaybe<Scalars['Int']>>>;
  lt?: InputMaybe<Scalars['Int']>;
  lte?: InputMaybe<Scalars['Int']>;
  neq?: InputMaybe<Scalars['Int']>;
  ngt?: InputMaybe<Scalars['Int']>;
  ngte?: InputMaybe<Scalars['Int']>;
  nin?: InputMaybe<Array<InputMaybe<Scalars['Int']>>>;
  nlt?: InputMaybe<Scalars['Int']>;
  nlte?: InputMaybe<Scalars['Int']>;
};

export type Mutation = {
  __typename?: 'Mutation';
  createCategory: CategoryResponseDto;
  createFlashCard: FlashCardResponseDto;
  deleteCategory: CategoryResponseDto;
  deleteFlashCard: FlashCardResponseDto;
  updateFlashCard: FlashCardResponseDto;
};


export type MutationCreateCategoryArgs = {
  command: CreateCategoryCommandInput;
};


export type MutationCreateFlashCardArgs = {
  command: CreateFlashCardCommandInput;
};


export type MutationDeleteCategoryArgs = {
  command: DeleteCategoryCommandInput;
};


export type MutationDeleteFlashCardArgs = {
  command: DeleteFlashCardInput;
};


export type MutationUpdateFlashCardArgs = {
  command: UpdateFlashCardInput;
};

export type Query = {
  __typename?: 'Query';
  allCategories: Array<CategoryDto>;
  allTags: Array<TagDto>;
  runFlashCards: Array<FlashCardDto>;
};


export type QueryAllCategoriesArgs = {
  page?: Scalars['Int'];
  pageSize?: Scalars['Int'];
  userId?: InputMaybe<Scalars['String']>;
  where?: InputMaybe<CategoryDtoFilterInput>;
};


export type QueryAllTagsArgs = {
  flashCardId?: InputMaybe<Scalars['String']>;
  where?: InputMaybe<TagDtoFilterInput>;
};


export type QueryRunFlashCardsArgs = {
  frequency: Frequency;
  userId: Scalars['String'];
  where?: InputMaybe<FlashCardDtoFilterInput>;
};

export type StringOperationFilterInput = {
  and?: InputMaybe<Array<StringOperationFilterInput>>;
  contains?: InputMaybe<Scalars['String']>;
  endsWith?: InputMaybe<Scalars['String']>;
  eq?: InputMaybe<Scalars['String']>;
  in?: InputMaybe<Array<InputMaybe<Scalars['String']>>>;
  ncontains?: InputMaybe<Scalars['String']>;
  nendsWith?: InputMaybe<Scalars['String']>;
  neq?: InputMaybe<Scalars['String']>;
  nin?: InputMaybe<Array<InputMaybe<Scalars['String']>>>;
  nstartsWith?: InputMaybe<Scalars['String']>;
  or?: InputMaybe<Array<StringOperationFilterInput>>;
  startsWith?: InputMaybe<Scalars['String']>;
};

export type TagDto = {
  __typename?: 'TagDto';
  name: Scalars['String'];
  tagId: Scalars['Int'];
};

export type TagDtoFilterInput = {
  and?: InputMaybe<Array<TagDtoFilterInput>>;
  name?: InputMaybe<StringOperationFilterInput>;
  or?: InputMaybe<Array<TagDtoFilterInput>>;
  tagId?: InputMaybe<IntOperationFilterInput>;
};

export type UpdateFlashCardInput = {
  backText: Scalars['String'];
  categoryId: Scalars['String'];
  frequency: Frequency;
  frontText: Scalars['String'];
  id: Scalars['String'];
};

export type UuidOperationFilterInput = {
  eq?: InputMaybe<Scalars['UUID']>;
  gt?: InputMaybe<Scalars['UUID']>;
  gte?: InputMaybe<Scalars['UUID']>;
  in?: InputMaybe<Array<InputMaybe<Scalars['UUID']>>>;
  lt?: InputMaybe<Scalars['UUID']>;
  lte?: InputMaybe<Scalars['UUID']>;
  neq?: InputMaybe<Scalars['UUID']>;
  ngt?: InputMaybe<Scalars['UUID']>;
  ngte?: InputMaybe<Scalars['UUID']>;
  nin?: InputMaybe<Array<InputMaybe<Scalars['UUID']>>>;
  nlt?: InputMaybe<Scalars['UUID']>;
  nlte?: InputMaybe<Scalars['UUID']>;
};

export type GetCategoriesQueryVariables = Exact<{ [key: string]: never; }>;


export type GetCategoriesQuery = { __typename?: 'Query', allCategories: Array<{ __typename?: 'CategoryDto', categoryID: any, name: string }> };


export const GetCategoriesDocument = gql`
    query GetCategories {
  allCategories {
    categoryID
    name
  }
}
    `;

/**
 * __useGetCategoriesQuery__
 *
 * To run a query within a React component, call `useGetCategoriesQuery` and pass it any options that fit your needs.
 * When your component renders, `useGetCategoriesQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useGetCategoriesQuery({
 *   variables: {
 *   },
 * });
 */
export function useGetCategoriesQuery(baseOptions?: Apollo.QueryHookOptions<GetCategoriesQuery, GetCategoriesQueryVariables>) {
        const options = {...defaultOptions, ...baseOptions}
        return Apollo.useQuery<GetCategoriesQuery, GetCategoriesQueryVariables>(GetCategoriesDocument, options);
      }
export function useGetCategoriesLazyQuery(baseOptions?: Apollo.LazyQueryHookOptions<GetCategoriesQuery, GetCategoriesQueryVariables>) {
          const options = {...defaultOptions, ...baseOptions}
          return Apollo.useLazyQuery<GetCategoriesQuery, GetCategoriesQueryVariables>(GetCategoriesDocument, options);
        }
export type GetCategoriesQueryHookResult = ReturnType<typeof useGetCategoriesQuery>;
export type GetCategoriesLazyQueryHookResult = ReturnType<typeof useGetCategoriesLazyQuery>;
export type GetCategoriesQueryResult = Apollo.QueryResult<GetCategoriesQuery, GetCategoriesQueryVariables>;