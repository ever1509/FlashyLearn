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
  userID: Scalars['UUID'];
};

export type CategoryDtoFilterInput = {
  and?: InputMaybe<Array<CategoryDtoFilterInput>>;
  categoryID?: InputMaybe<UuidOperationFilterInput>;
  name?: InputMaybe<StringOperationFilterInput>;
  or?: InputMaybe<Array<CategoryDtoFilterInput>>;
  userID?: InputMaybe<UuidOperationFilterInput>;
};

export type CategoryResponseDto = {
  __typename?: 'CategoryResponseDto';
  categoryID: Scalars['UUID'];
  name: Scalars['String'];
  userID?: Maybe<Scalars['UUID']>;
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
  categoryID: Scalars['UUID'];
  flashCardID: Scalars['UUID'];
  frequency: Frequency;
  frontText: Scalars['String'];
};

export type FlashCardDtoFilterInput = {
  and?: InputMaybe<Array<FlashCardDtoFilterInput>>;
  backText?: InputMaybe<StringOperationFilterInput>;
  categoryID?: InputMaybe<UuidOperationFilterInput>;
  flashCardID?: InputMaybe<UuidOperationFilterInput>;
  frequency?: InputMaybe<FrequencyOperationFilterInput>;
  frontText?: InputMaybe<StringOperationFilterInput>;
  or?: InputMaybe<Array<FlashCardDtoFilterInput>>;
};

export type FlashCardResponseDto = {
  __typename?: 'FlashCardResponseDto';
  backText: Scalars['String'];
  categoryID: Scalars['UUID'];
  flashCardID: Scalars['UUID'];
  frontText: Scalars['String'];
};

export enum Frequency {
  Daily = 'DAILY',
  Monthly = 'MONTHLY',
  Weekly = 'WEEKLY'
}

export type FrequencyOperationFilterInput = {
  eq?: InputMaybe<Frequency>;
  in?: InputMaybe<Array<Frequency>>;
  neq?: InputMaybe<Frequency>;
  nin?: InputMaybe<Array<Frequency>>;
};

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
  deleteCategory: CategoryResponseDto;
  deleteFlashCard: FlashCardResponseDto;
  saveCategory: CategoryResponseDto;
  saveFlashCard: FlashCardResponseDto;
};


export type MutationDeleteCategoryArgs = {
  command: DeleteCategoryCommandInput;
};


export type MutationDeleteFlashCardArgs = {
  command: DeleteFlashCardInput;
};


export type MutationSaveCategoryArgs = {
  command: SaveCategoryCommandInput;
};


export type MutationSaveFlashCardArgs = {
  command: SaveFlashCardCommandInput;
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
  where?: InputMaybe<FlashCardDtoFilterInput>;
};

export type SaveCategoryCommandInput = {
  categoryID?: InputMaybe<Scalars['String']>;
  name: Scalars['String'];
  userID?: InputMaybe<Scalars['String']>;
};

export type SaveFlashCardCommandInput = {
  backText: Scalars['String'];
  categoryID: Scalars['String'];
  flashcarID?: InputMaybe<Scalars['String']>;
  frequency: Frequency;
  frontText: Scalars['String'];
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

export type DeleteCategoryMutationVariables = Exact<{
  id: Scalars['String'];
}>;


export type DeleteCategoryMutation = { __typename?: 'Mutation', deleteCategory: { __typename?: 'CategoryResponseDto', categoryID: any, name: string, userID?: any | null } };

export type DeleteFlashCardMutationVariables = Exact<{
  id: Scalars['String'];
}>;


export type DeleteFlashCardMutation = { __typename?: 'Mutation', deleteFlashCard: { __typename?: 'FlashCardResponseDto', categoryID: any, flashCardID: any, backText: string, frontText: string } };

export type CreateCategoryMutationVariables = Exact<{
  category: SaveCategoryCommandInput;
}>;


export type CreateCategoryMutation = { __typename?: 'Mutation', saveCategory: { __typename?: 'CategoryResponseDto', categoryID: any, name: string, userID?: any | null } };

export type SaveFlashCardMutationVariables = Exact<{
  flashCard: SaveFlashCardCommandInput;
}>;


export type SaveFlashCardMutation = { __typename?: 'Mutation', saveFlashCard: { __typename?: 'FlashCardResponseDto', backText: string, frontText: string, flashCardID: any, categoryID: any } };

export type GetCategoriesQueryVariables = Exact<{ [key: string]: never; }>;


export type GetCategoriesQuery = { __typename?: 'Query', allCategories: Array<{ __typename?: 'CategoryDto', categoryID: any, name: string, userID: any }> };

export type GetCategoryByIdQueryVariables = Exact<{
  id: Scalars['UUID'];
}>;


export type GetCategoryByIdQuery = { __typename?: 'Query', allCategories: Array<{ __typename?: 'CategoryDto', categoryID: any, name: string, userID: any }> };

export type AllTagsQueryVariables = Exact<{
  flashCardID: Scalars['String'];
}>;


export type AllTagsQuery = { __typename?: 'Query', allTags: Array<{ __typename?: 'TagDto', tagId: number, name: string }> };

export type RunFlashardsQueryVariables = Exact<{ [key: string]: never; }>;


export type RunFlashardsQuery = { __typename?: 'Query', runFlashCards: Array<{ __typename?: 'FlashCardDto', categoryID: any, flashCardID: any, frontText: string, backText: string, frequency: Frequency }> };

export type RunFlashardByIdQueryVariables = Exact<{
  id: Scalars['UUID'];
}>;


export type RunFlashardByIdQuery = { __typename?: 'Query', runFlashCards: Array<{ __typename?: 'FlashCardDto', categoryID: any, flashCardID: any, frontText: string, backText: string, frequency: Frequency }> };


export const DeleteCategoryDocument = gql`
    mutation DeleteCategory($id: String!) {
  deleteCategory(command: {id: $id}) {
    categoryID
    name
    userID
  }
}
    `;
export type DeleteCategoryMutationFn = Apollo.MutationFunction<DeleteCategoryMutation, DeleteCategoryMutationVariables>;

/**
 * __useDeleteCategoryMutation__
 *
 * To run a mutation, you first call `useDeleteCategoryMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useDeleteCategoryMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [deleteCategoryMutation, { data, loading, error }] = useDeleteCategoryMutation({
 *   variables: {
 *      id: // value for 'id'
 *   },
 * });
 */
export function useDeleteCategoryMutation(baseOptions?: Apollo.MutationHookOptions<DeleteCategoryMutation, DeleteCategoryMutationVariables>) {
        const options = {...defaultOptions, ...baseOptions}
        return Apollo.useMutation<DeleteCategoryMutation, DeleteCategoryMutationVariables>(DeleteCategoryDocument, options);
      }
export type DeleteCategoryMutationHookResult = ReturnType<typeof useDeleteCategoryMutation>;
export type DeleteCategoryMutationResult = Apollo.MutationResult<DeleteCategoryMutation>;
export type DeleteCategoryMutationOptions = Apollo.BaseMutationOptions<DeleteCategoryMutation, DeleteCategoryMutationVariables>;
export const DeleteFlashCardDocument = gql`
    mutation DeleteFlashCard($id: String!) {
  deleteFlashCard(command: {id: $id}) {
    categoryID
    flashCardID
    backText
    frontText
  }
}
    `;
export type DeleteFlashCardMutationFn = Apollo.MutationFunction<DeleteFlashCardMutation, DeleteFlashCardMutationVariables>;

/**
 * __useDeleteFlashCardMutation__
 *
 * To run a mutation, you first call `useDeleteFlashCardMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useDeleteFlashCardMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [deleteFlashCardMutation, { data, loading, error }] = useDeleteFlashCardMutation({
 *   variables: {
 *      id: // value for 'id'
 *   },
 * });
 */
export function useDeleteFlashCardMutation(baseOptions?: Apollo.MutationHookOptions<DeleteFlashCardMutation, DeleteFlashCardMutationVariables>) {
        const options = {...defaultOptions, ...baseOptions}
        return Apollo.useMutation<DeleteFlashCardMutation, DeleteFlashCardMutationVariables>(DeleteFlashCardDocument, options);
      }
export type DeleteFlashCardMutationHookResult = ReturnType<typeof useDeleteFlashCardMutation>;
export type DeleteFlashCardMutationResult = Apollo.MutationResult<DeleteFlashCardMutation>;
export type DeleteFlashCardMutationOptions = Apollo.BaseMutationOptions<DeleteFlashCardMutation, DeleteFlashCardMutationVariables>;
export const CreateCategoryDocument = gql`
    mutation CreateCategory($category: SaveCategoryCommandInput!) {
  saveCategory(command: $category) {
    categoryID
    name
    userID
  }
}
    `;
export type CreateCategoryMutationFn = Apollo.MutationFunction<CreateCategoryMutation, CreateCategoryMutationVariables>;

/**
 * __useCreateCategoryMutation__
 *
 * To run a mutation, you first call `useCreateCategoryMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useCreateCategoryMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [createCategoryMutation, { data, loading, error }] = useCreateCategoryMutation({
 *   variables: {
 *      category: // value for 'category'
 *   },
 * });
 */
export function useCreateCategoryMutation(baseOptions?: Apollo.MutationHookOptions<CreateCategoryMutation, CreateCategoryMutationVariables>) {
        const options = {...defaultOptions, ...baseOptions}
        return Apollo.useMutation<CreateCategoryMutation, CreateCategoryMutationVariables>(CreateCategoryDocument, options);
      }
export type CreateCategoryMutationHookResult = ReturnType<typeof useCreateCategoryMutation>;
export type CreateCategoryMutationResult = Apollo.MutationResult<CreateCategoryMutation>;
export type CreateCategoryMutationOptions = Apollo.BaseMutationOptions<CreateCategoryMutation, CreateCategoryMutationVariables>;
export const SaveFlashCardDocument = gql`
    mutation SaveFlashCard($flashCard: SaveFlashCardCommandInput!) {
  saveFlashCard(command: $flashCard) {
    backText
    frontText
    flashCardID
    categoryID
  }
}
    `;
export type SaveFlashCardMutationFn = Apollo.MutationFunction<SaveFlashCardMutation, SaveFlashCardMutationVariables>;

/**
 * __useSaveFlashCardMutation__
 *
 * To run a mutation, you first call `useSaveFlashCardMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useSaveFlashCardMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [saveFlashCardMutation, { data, loading, error }] = useSaveFlashCardMutation({
 *   variables: {
 *      flashCard: // value for 'flashCard'
 *   },
 * });
 */
export function useSaveFlashCardMutation(baseOptions?: Apollo.MutationHookOptions<SaveFlashCardMutation, SaveFlashCardMutationVariables>) {
        const options = {...defaultOptions, ...baseOptions}
        return Apollo.useMutation<SaveFlashCardMutation, SaveFlashCardMutationVariables>(SaveFlashCardDocument, options);
      }
export type SaveFlashCardMutationHookResult = ReturnType<typeof useSaveFlashCardMutation>;
export type SaveFlashCardMutationResult = Apollo.MutationResult<SaveFlashCardMutation>;
export type SaveFlashCardMutationOptions = Apollo.BaseMutationOptions<SaveFlashCardMutation, SaveFlashCardMutationVariables>;
export const GetCategoriesDocument = gql`
    query GetCategories {
  allCategories {
    categoryID
    name
    userID
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
export const GetCategoryByIdDocument = gql`
    query GetCategoryById($id: UUID!) {
  allCategories(where: {categoryID: {eq: $id}}) {
    categoryID
    name
    userID
  }
}
    `;

/**
 * __useGetCategoryByIdQuery__
 *
 * To run a query within a React component, call `useGetCategoryByIdQuery` and pass it any options that fit your needs.
 * When your component renders, `useGetCategoryByIdQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useGetCategoryByIdQuery({
 *   variables: {
 *      id: // value for 'id'
 *   },
 * });
 */
export function useGetCategoryByIdQuery(baseOptions: Apollo.QueryHookOptions<GetCategoryByIdQuery, GetCategoryByIdQueryVariables>) {
        const options = {...defaultOptions, ...baseOptions}
        return Apollo.useQuery<GetCategoryByIdQuery, GetCategoryByIdQueryVariables>(GetCategoryByIdDocument, options);
      }
export function useGetCategoryByIdLazyQuery(baseOptions?: Apollo.LazyQueryHookOptions<GetCategoryByIdQuery, GetCategoryByIdQueryVariables>) {
          const options = {...defaultOptions, ...baseOptions}
          return Apollo.useLazyQuery<GetCategoryByIdQuery, GetCategoryByIdQueryVariables>(GetCategoryByIdDocument, options);
        }
export type GetCategoryByIdQueryHookResult = ReturnType<typeof useGetCategoryByIdQuery>;
export type GetCategoryByIdLazyQueryHookResult = ReturnType<typeof useGetCategoryByIdLazyQuery>;
export type GetCategoryByIdQueryResult = Apollo.QueryResult<GetCategoryByIdQuery, GetCategoryByIdQueryVariables>;
export const AllTagsDocument = gql`
    query AllTags($flashCardID: String!) {
  allTags(flashCardId: $flashCardID) {
    tagId
    name
  }
}
    `;

/**
 * __useAllTagsQuery__
 *
 * To run a query within a React component, call `useAllTagsQuery` and pass it any options that fit your needs.
 * When your component renders, `useAllTagsQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useAllTagsQuery({
 *   variables: {
 *      flashCardID: // value for 'flashCardID'
 *   },
 * });
 */
export function useAllTagsQuery(baseOptions: Apollo.QueryHookOptions<AllTagsQuery, AllTagsQueryVariables>) {
        const options = {...defaultOptions, ...baseOptions}
        return Apollo.useQuery<AllTagsQuery, AllTagsQueryVariables>(AllTagsDocument, options);
      }
export function useAllTagsLazyQuery(baseOptions?: Apollo.LazyQueryHookOptions<AllTagsQuery, AllTagsQueryVariables>) {
          const options = {...defaultOptions, ...baseOptions}
          return Apollo.useLazyQuery<AllTagsQuery, AllTagsQueryVariables>(AllTagsDocument, options);
        }
export type AllTagsQueryHookResult = ReturnType<typeof useAllTagsQuery>;
export type AllTagsLazyQueryHookResult = ReturnType<typeof useAllTagsLazyQuery>;
export type AllTagsQueryResult = Apollo.QueryResult<AllTagsQuery, AllTagsQueryVariables>;
export const RunFlashardsDocument = gql`
    query RunFlashards {
  runFlashCards {
    categoryID
    flashCardID
    frontText
    backText
    frequency
  }
}
    `;

/**
 * __useRunFlashardsQuery__
 *
 * To run a query within a React component, call `useRunFlashardsQuery` and pass it any options that fit your needs.
 * When your component renders, `useRunFlashardsQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useRunFlashardsQuery({
 *   variables: {
 *   },
 * });
 */
export function useRunFlashardsQuery(baseOptions?: Apollo.QueryHookOptions<RunFlashardsQuery, RunFlashardsQueryVariables>) {
        const options = {...defaultOptions, ...baseOptions}
        return Apollo.useQuery<RunFlashardsQuery, RunFlashardsQueryVariables>(RunFlashardsDocument, options);
      }
export function useRunFlashardsLazyQuery(baseOptions?: Apollo.LazyQueryHookOptions<RunFlashardsQuery, RunFlashardsQueryVariables>) {
          const options = {...defaultOptions, ...baseOptions}
          return Apollo.useLazyQuery<RunFlashardsQuery, RunFlashardsQueryVariables>(RunFlashardsDocument, options);
        }
export type RunFlashardsQueryHookResult = ReturnType<typeof useRunFlashardsQuery>;
export type RunFlashardsLazyQueryHookResult = ReturnType<typeof useRunFlashardsLazyQuery>;
export type RunFlashardsQueryResult = Apollo.QueryResult<RunFlashardsQuery, RunFlashardsQueryVariables>;
export const RunFlashardByIdDocument = gql`
    query RunFlashardById($id: UUID!) {
  runFlashCards(where: {flashCardID: {eq: $id}}) {
    categoryID
    flashCardID
    frontText
    backText
    frequency
  }
}
    `;

/**
 * __useRunFlashardByIdQuery__
 *
 * To run a query within a React component, call `useRunFlashardByIdQuery` and pass it any options that fit your needs.
 * When your component renders, `useRunFlashardByIdQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useRunFlashardByIdQuery({
 *   variables: {
 *      id: // value for 'id'
 *   },
 * });
 */
export function useRunFlashardByIdQuery(baseOptions: Apollo.QueryHookOptions<RunFlashardByIdQuery, RunFlashardByIdQueryVariables>) {
        const options = {...defaultOptions, ...baseOptions}
        return Apollo.useQuery<RunFlashardByIdQuery, RunFlashardByIdQueryVariables>(RunFlashardByIdDocument, options);
      }
export function useRunFlashardByIdLazyQuery(baseOptions?: Apollo.LazyQueryHookOptions<RunFlashardByIdQuery, RunFlashardByIdQueryVariables>) {
          const options = {...defaultOptions, ...baseOptions}
          return Apollo.useLazyQuery<RunFlashardByIdQuery, RunFlashardByIdQueryVariables>(RunFlashardByIdDocument, options);
        }
export type RunFlashardByIdQueryHookResult = ReturnType<typeof useRunFlashardByIdQuery>;
export type RunFlashardByIdLazyQueryHookResult = ReturnType<typeof useRunFlashardByIdLazyQuery>;
export type RunFlashardByIdQueryResult = Apollo.QueryResult<RunFlashardByIdQuery, RunFlashardByIdQueryVariables>;